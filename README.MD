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

### 1. Presentation
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Std.Pre.Com.Model](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/01/Com/Std.Pre.Com.Model) | [![NuGet](https://img.shields.io/nuget/v/Std.Pre.Com.Model)](https://www.nuget.org/packages/Std.Pre.Com.Model) | ![NuGet](https://img.shields.io/nuget/dt/Std.Pre.Com.Model) |

### 2. Service
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Std.Srv.Host.Com.Shared](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/02/Host/Com/Std.Srv.Host.Com.Shared) | [![NuGet](https://img.shields.io/nuget/v/Std.Srv.Host.Com.Shared)](https://www.nuget.org/packages/Std.Srv.Host.Com.Shared) | ![NuGet](https://img.shields.io/nuget/dt/Std.Srv.Host.Com.Shared) |
| [Srv.Agent](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/02/Com/Srv.Agent) | [![NuGet](https://img.shields.io/nuget/v/Srv.Agent)](https://www.nuget.org/packages/Srv.Agent) | ![NuGet](https://img.shields.io/nuget/dt/Srv.Agent) |
| [Srv.Behavior](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/02/Com/Srv.Behavior) | [![NuGet](https://img.shields.io/nuget/v/Srv.Behavior)](https://www.nuget.org/packages/Srv.Behavior) | ![NuGet](https://img.shields.io/nuget/dt/Srv.Behavior) |
| [Srv.Contract](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/02/Com/Srv.Contract) | [![NuGet](https://img.shields.io/nuget/v/Srv.Contract)](https://www.nuget.org/packages/Srv.Contract) | ![NuGet](https://img.shields.io/nuget/dt/Srv.Contract) |
| [Srv.Dto](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/02/Com/Srv.Dto) | [![NuGet](https://img.shields.io/nuget/v/Srv.Dto)](https://www.nuget.org/packages/Srv.Dto) | ![NuGet](https://img.shields.io/nuget/dt/Srv.Dto) |

### 3. Application
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Std.App.Com.Dto](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/03/Com/Std.App.Com.Dto) | [![NuGet](https://img.shields.io/nuget/v/Std.App.Com.Dto)](https://www.nuget.org/packages/Std.App.Com.Dto) | ![NuGet](https://img.shields.io/nuget/dt/Std.App.Com.Dto) |
| [Std.App.Com.ReqHdlr](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/03/Com/Std.App.Com.ReqHdlr) | [![NuGet](https://img.shields.io/nuget/v/Std.App.Com.ReqHdlr)](https://www.nuget.org/packages/Std.App.Com.ReqHdlr) | ![NuGet](https://img.shields.io/nuget/dt/Std.App.Com.ReqHdlr) |

### 4. Business
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Std.Biz.Com](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/04/Com/Std.Biz.Com) | [![NuGet](https://img.shields.io/nuget/v/Std.Biz.Com)](https://www.nuget.org/packages/Std.Biz.Com) | ![NuGet](https://img.shields.io/nuget/dt/Std.Biz.Com) |

### 5. Domain
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Domain.Entity](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/05/Com/Domain.Entity) | [![NuGet](https://img.shields.io/nuget/v/Domain.Entity)](https://www.nuget.org/packages/Domain.Entity) | ![NuGet](https://img.shields.io/nuget/dt/Domain.Entity) |
| [Domain.Repository](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/05/Com/Domain.Repository) | [![NuGet](https://img.shields.io/nuget/v/Domain.Repository)](https://www.nuget.org/packages/Domain.Repository) | ![NuGet](https://img.shields.io/nuget/dt/Domain.Repository) |

### 6. Infrastructure
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Std.Infra.Com.DataAccess](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/06/Com/Std.Infra.Com.DataAccess) | [![NuGet](https://img.shields.io/nuget/v/Std.Infra.Com.DataAccess)](https://www.nuget.org/packages/Std.Infra.Com.DataAccess) | ![NuGet](https://img.shields.io/nuget/dt/Std.Infra.Com.DataAccess) |

### Communication Driver
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Std.Com.Driver](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/Communication/Std.Com.Driver) | [![NuGet](https://img.shields.io/nuget/v/Std.Com.Driver)](https://www.nuget.org/packages/Std.Com.Driver) | ![NuGet](https://img.shields.io/nuget/dt/Std.Com.Driver) |


### EventBus
| GitHub Repository | NuGet | Download |
| ------------- | ------------- | ------------- |
| [Std.EventBus.Com](https://github.com/K-Society/Std.Master.Com/tree/master/Src/01/StdEventBus/Com/Std.EventBus.Com) | [![NuGet](https://img.shields.io/nuget/v/Std.EventBus.Com)](https://www.nuget.org/packages/Std.EventBus.Com) | ![NuGet](https://img.shields.io/nuget/dt/Std.EventBus.Com) |
