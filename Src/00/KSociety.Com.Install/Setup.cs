using System;
using WixSharp;
using WixSharp.Bootstrapper;

namespace KSociety.Com.Install
{
    internal static class Setup
    {
        private const string Product = "Com";
        private const string Manufacturer = "K-Society";
        private static string _comSystemVersion = "1.0.0.0";

        public static void Main()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            _comSystemVersion = fileVersionInfo.FileVersion;

            var productMsiUninstall = BuildMsiUninstall();
            var productMsiComPresenter = BuildMsiComPresenter();
            var productMsiComServer = BuildMsiComServer();
            var productMsiRegistryX86 = BuildMsiRegistryX86();
            var productMsiRegistryX64 = BuildMsiRegistryX64();

            var bootstrapper =
                new Bundle(Manufacturer + "." + Product,
                    new MsiPackage(productMsiUninstall)
                    {
                        DisplayInternalUI = false,
                        Compressed = true,
                        Visible = false,
                        Cache = false,
                        MsiProperties = "UNINSTALLER_PATH=[UNINSTALLER_PATH]"
                    },
                    new MsiPackage(productMsiComPresenter)
                    {
                        DisplayInternalUI = false,
                        Compressed = true,
                        Visible = false
                    },
                    new MsiPackage(productMsiComServer)
                    {
                        DisplayInternalUI = false,
                        Compressed = true,
                        Visible = false
                    },
                    new MsiPackage(productMsiRegistryX86) { DisplayInternalUI = false, Compressed = true, InstallCondition = "NOT VersionNT64" },
                    new MsiPackage(productMsiRegistryX64) { DisplayInternalUI = false, Compressed = true, InstallCondition = "VersionNT64" }
                )
                {
                    UpgradeCode = new Guid("BBD5FA92-3E78-4CD8-AD3A-8EC4AEC889F7"),
                    Version = new Version(_comSystemVersion),
                    Manufacturer = Manufacturer,
                    AboutUrl = "https://github.com/K-Society/KSociety.Com",
                    Id = "Com_System",
                    //IconFile = @"..\..\..\assets\icon\icon.ico",
                    Variables = new []
                    {
                        new Variable("UNINSTALLER_PATH",
                            $@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\{"Package Cache"}\{"[WixBundleProviderKey]"}\{Manufacturer + "." + Product}.exe")
                    }
                };

            bootstrapper.Build(Manufacturer + "." + Product + ".exe");

            if (System.IO.File.Exists(productMsiUninstall))
            {
                System.IO.File.Delete(productMsiUninstall);
            }

            if (System.IO.File.Exists(productMsiComPresenter))
            {
                System.IO.File.Delete(productMsiComPresenter);
            }

            if (System.IO.File.Exists(productMsiComServer))
            {
                System.IO.File.Delete(productMsiComServer);
            }

            if (System.IO.File.Exists(productMsiRegistryX86)) { System.IO.File.Delete(productMsiRegistryX86); }
            if (System.IO.File.Exists(productMsiRegistryX64)) { System.IO.File.Delete(productMsiRegistryX64); }
        }

        private static string BuildMsiUninstall()
        {
            var project =
                new Project(Product + " Uninstall",
                    new Dir(@"%ProgramMenu%\" + Manufacturer + @"\" + Product,
                        new ExeFileShortcut("Uninstall " + Product, "[UNINSTALLER_PATH]", "")
                    )
                )
                {
                    InstallScope = InstallScope.perMachine,
                    Version = new Version("1.0.0.0"),
                    GUID = new Guid("4563FF04-CFE7-4638-BFD4-5436AE1AFA18"),
                    ControlPanelInfo = new ProductInfo
                    {
                        Manufacturer = Manufacturer
                    }
                };
            return project.BuildMsi();
        }

        private static string BuildMsiComPresenter()
        {
            Environment.SetEnvironmentVariable("ComPresenter",
                @"..\..\..\build\KSociety.Com.Pre.Web.App\Release\net6.0\publish");

            #region [Firewall]

            var serviceComPresenterFw = new FirewallException
            {
                Id = "COM_PRESENTER_ID",
                Description = "ComPresenter",
                Name = "ComPresenter",
                IgnoreFailure = true,
                Profile = FirewallExceptionProfile.all,
                Scope = FirewallExceptionScope.any
            };

            #endregion

            #region [Feature]

            Feature binaries = new Feature("Binaries", "Binaries", true, false);
            Feature comPresenter = new Feature("ComPresenter", "ComPresenter", true);

            binaries.Children.Add(comPresenter);

            #endregion

            File comPresenterFile;

            Project project = new Project("ComPresenter",
                new Dir(new Id("INSTALLDIR"), @"%ProgramFiles%\" + Manufacturer + @"\" + Product,
                    new Dir(new Id("COMPRESENTERDIR"), comPresenter, "Presenter",
                        new Files(comPresenter, @"%ComPresenter%\*.*", f => !f.Contains("KSociety.Com.Pre.Web.App.exe")),
                        comPresenterFile = new File(comPresenter, @"%ComPresenter%\KSociety.Com.Pre.Web.App.exe", serviceComPresenterFw)
                    ) // LOGSERVER.
                ) // INSTALLDIR.
            )
            {
                InstallScope = InstallScope.perMachine,
                Platform = Platform.x64,
                Version = new Version("1.0.0.0"),
                GUID = new Guid("70E96335-9728-415C-B71A-4507A3B1C1D9"),
                UI = WUI.WixUI_ProgressOnly,
                ControlPanelInfo = new ProductInfo
                {
                    Manufacturer = Manufacturer
                }
            };

            comPresenterFile.ServiceInstaller = new ServiceInstaller
            {
                Id = "COMPRESENTER",
                Name = Manufacturer + "." + Product + "Presenter",
                Description = Manufacturer + "." + Product + " - Presenter",
                StartOn = null,
                StopOn = SvcEvent.InstallUninstall_Wait,
                RemoveOn = SvcEvent.Uninstall_Wait,
                DelayedAutoStart = false,
                ServiceSid = ServiceSid.none,
                RestartServiceDelayInSeconds = 30,
                ResetPeriodInDays = 1,
                PreShutdownDelay = 1000 * 60 * 3,
                RebootMessage = "Failure actions do not specify reboot"
            };

            project.PreserveTempFiles = false;
            project.PreserveDbgFiles = false;

            return project.BuildMsi();
        }

        private static string BuildMsiComServer()
        {
            Environment.SetEnvironmentVariable("ComServer",
                @"..\..\..\build\KSociety.Com.Srv.Host\Release\net6.0\publish");

            #region [Firewall]

            var serviceComServerFw = new FirewallException
            {
                Id = "COM_SERVER_ID",
                Description = "ComServer",
                Name = "ComServer",
                IgnoreFailure = true,
                Profile = FirewallExceptionProfile.all,
                Scope = FirewallExceptionScope.any
            };

            #endregion

            #region [Feature]

            Feature binaries = new Feature("Binaries", "Binaries", true, false);
            Feature comServer = new Feature("ComServer", "ComServer", true);

            binaries.Children.Add(comServer);

            #endregion

            File comService;

            Project project = new Project("ComServer",
                new Dir(new Id("INSTALLDIR"), @"%ProgramFiles%\" + Manufacturer + @"\" + Product,
                    new Dir(new Id("LOGSERVERDIR"), comServer, "Server",
                        new Files(comServer, @"%ComServer%\*.*", f => !f.Contains("KSociety.Com.Srv.Host.exe")),
                        comService = new File(comServer, @"%ComServer%\KSociety.Com.Srv.Host.exe", serviceComServerFw)
                    ) // LOGSERVER.
                ) // INSTALLDIR.
            )
            {
                InstallScope = InstallScope.perMachine,
                Platform = Platform.x64,
                Version = new Version("1.0.0.0"),
                GUID = new Guid("8B826B78-29EE-49D0-B7E7-638B450DE4F5"),
                UI = WUI.WixUI_ProgressOnly,
                ControlPanelInfo = new ProductInfo
                {
                    Manufacturer = Manufacturer
                }
            };

            comService.ServiceInstaller = new ServiceInstaller
            {
                Id = "COMSERVER",
                Name = Manufacturer + "." + Product + "Server",
                Description = Manufacturer + "." + Product + " - Server",
                StartOn = null,
                StopOn = SvcEvent.InstallUninstall_Wait,
                RemoveOn = SvcEvent.Uninstall_Wait,
                DelayedAutoStart = true,
                ServiceSid = ServiceSid.none,
                RestartServiceDelayInSeconds = 30,
                ResetPeriodInDays = 1,
                PreShutdownDelay = 1000 * 60 * 3,
                RebootMessage = "Failure actions do not specify reboot"
            };

            project.PreserveTempFiles = false;
            project.PreserveDbgFiles = false;

            return project.BuildMsi();
        }

        private static string BuildMsiRegistryX86()
        {
            Compiler.AutoGeneration.InstallDirDefaultId = null;
            var registry = new Feature("RegistryX86");
            var project =
                new Project(Product + " RegistryX86",
                    new RegKey(registry, RegistryHive.LocalMachine, @"SOFTWARE\" + Manufacturer + @"\" + Product,

                        new RegValue("Version", _comSystemVersion)),

                    new RemoveRegistryValue(registry, @"SOFTWARE\" + Manufacturer + @"\" + Product)
                )
                {
                    InstallScope = InstallScope.perMachine,
                    Version = new Version("1.0.0.0"),
                    GUID = new Guid("3D7EE800-90A0-43D2-86FD-31ABD3BAFA30"),
                    UI = WUI.WixUI_ProgressOnly,
                    ControlPanelInfo = new ProductInfo
                    {
                        Manufacturer = Manufacturer
                    }
                };

            return project.BuildMsi();
        }// BuildMsiRegistryX86.

        private static string BuildMsiRegistryX64()
        {
            Compiler.AutoGeneration.InstallDirDefaultId = null;
            var registry = new Feature("RegistryX64");
            var project =
                new Project(Product + " RegistryX64",
                    new RegKey(registry, RegistryHive.LocalMachine, @"SOFTWARE\" + Manufacturer + @"\" + Product,

                        new RegValue("Version", _comSystemVersion))
                    {
                        Win64 = true
                    },

                    new RemoveRegistryValue(registry, @"SOFTWARE\" + Manufacturer + @"\" + Product)
                )
                {
                    InstallScope = InstallScope.perMachine,
                    Platform = Platform.x64,
                    Version = new Version("1.0.0.0"),
                    GUID = new Guid("8DFEA935-6D4E-46DD-BF1A-D3A5D5CB8827"),
                    UI = WUI.WixUI_ProgressOnly,
                    ControlPanelInfo = new ProductInfo
                    {
                        Manufacturer = Manufacturer
                    }
                };
            return project.BuildMsi();
        }// BuildMsiRegistryX64.
    }
}
