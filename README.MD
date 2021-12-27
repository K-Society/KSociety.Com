[![Build status](https://ci.appveyor.com/api/projects/status/vw2wblpsxwihbuoo?svg=true)](https://ci.appveyor.com/project/maniglia/ksociety-com)
![GitHub all releases](https://img.shields.io/github/downloads/K-Society/KSociety.Com/total)
# KSociety.Com - Communication System
#### A .NET full stack software for Siemens S7 Connectivity

## Overview

KSociety.Com is a full stack software consisting of:
- a service that reads or writes data to a plc
- a web application for the parameterization of the service

This system needs [RabbitMQ](https://github.com/K-Society/KSociety.RabbitMQ.Install/releases) as a message-oriented middleware.

## Introduction

This is the README file for KSociety.Com. It support .Net 6.0

## Supported frameworks

+ .NET 6.0

## Supported PLC

+ Compatible S7 PLC (S7-200, S7-300, S7-400, S7-1200, S7-1500)

## Install

This system needs [RabbitMQ](https://github.com/K-Society/KSociety.RabbitMQ.Install/releases) to function properly.

## Architecture

![Image of Architecture](https://github.com/K-Society/KSociety.Com/blob/experimental/docs/Architecture_view_for_KSociety.Com.png)

### 1. Presentation (KSociety.Com.Pre.Web.)
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [App](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/01/Web/KSociety.Com.Pre.Web.App) |  |  |

### 2. Service (KSociety.Com.Srv.)
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Agent](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/02/KSociety.Com.Srv.Agent) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.Srv.Agent)](https://www.nuget.org/packages/KSociety.Com.Srv.Agent) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.Srv.Agent) |
| [Behavior](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/02/KSociety.Com.Srv.Behavior) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.Srv.Behavior)](https://www.nuget.org/packages/KSociety.Com.Srv.Behavior) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.Srv.Behavior) |
| [Contract](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/02/KSociety.Com.Srv.Contract) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.Srv.Contract)](https://www.nuget.org/packages/KSociety.Com.Srv.Contract) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.Srv.Contract) |
| [Dto](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/02/KSociety.Com.Srv.Dto) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.Srv.Dto)](https://www.nuget.org/packages/KSociety.Com.Srv.Dto) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.Srv.Dto) |

### 2.1 Service - Host (KSociety.Com.Srv.Host)

| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Host](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/02/Host/KSociety.Com.Srv.Host) |  |  |

### 3. Application (KSociety.Com.App.)
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Dto](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/03/KSociety.Com.App.Dto) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.App.Dto)](https://www.nuget.org/packages/KSociety.Com.App.Dto) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.App.Dto) |
| [ReqHdlr](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/03/KSociety.Com.App.ReqHdlr) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.App.ReqHdlr)](https://www.nuget.org/packages/KSociety.Com.App.ReqHdlr) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.App.ReqHdlr) |

### 4. Business (KSociety.Com.Biz.)
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Event](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/04/KSociety.Com.Biz.Event) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.Biz.Event)](https://www.nuget.org/packages/KSociety.Com.Biz.Event) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.Biz.Event) |
| [Biz](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/04/KSociety.Com.Biz) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.Biz)](https://www.nuget.org/packages/KSociety.Com.Biz) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.Biz) |

### 5. Domain (KSociety.Com.Domain.)
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Entity](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/05/KSociety.Com.Domain.Entity) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.Domain.Entity)](https://www.nuget.org/packages/KSociety.Com.Domain.Entity) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.Domain.Entity) |
| [Repository](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/05/KSociety.Com.Domain.Repository) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.Domain.Repository)](https://www.nuget.org/packages/KSociety.Com.Domain.Repository) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.Domain.Repository) |

### 6. Infrastructure (KSociety.Com.Infra.)
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [DataAccess](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/06/KSociety.Com.Infra.DataAccess) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.Infra.DataAccess)](https://www.nuget.org/packages/KSociety.Com.Infra.DataAccess) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.Infra.DataAccess) |
| [Transfer.SqlServer](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/06/KSociety.Com.Infra.Transfer.SqlServer) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.Infra.Transfer.SqlServer)](https://www.nuget.org/packages/KSociety.Com.Infra.Transfer.SqlServer) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.Infra.Transfer.SqlServer) |
| [Transfer.Sqlite](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/06/KSociety.Com.Infra.Transfer.Sqlite) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.Infra.Transfer.Sqlite)](https://www.nuget.org/packages/KSociety.Com.Infra.Transfer.Sqlite) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.Infra.Transfer.Sqlite) |

### Communication Driver
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [KSociety.Com.Driver](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/Communication/KSociety.Com.Driver) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.Driver)](https://www.nuget.org/packages/KSociety.Com.Driver) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.Driver) |


### EventBus
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [KSociety.Com.EventBus](https://github.com/K-Society/KSociety.Com/tree/master/Src/01/KSocietyComEventBus/KSociety.Com.EventBus) | [![NuGet](https://img.shields.io/nuget/v/KSociety.Com.EventBus)](https://www.nuget.org/packages/KSociety.Com.EventBus/) | ![NuGet](https://img.shields.io/nuget/dt/KSociety.Com.EventBus) |

## License
The project is under Microsoft Reciprocal License [(MS-RL)](http://www.opensource.org/licenses/MS-RL)

## Dependencies

List of technologies, frameworks and libraries used for implementation:

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) (platform). Note for Visual Studio users: **VS 2022** is required.
- [Autofac](https://autofac.org/) (Inversion of Control Container)
- [protobuf-net](https://github.com/protobuf-net/protobuf-net) (protobuf-net is a contract based serializer for .NET code)
- [RabbitMQ.Client](https://www.rabbitmq.com/dotnet.html) (The RabbitMQ .NET client is an implementation of an AMQP 0-9-1 client library for C#)
- [Serilog](https://serilog.net/) (structured logging)