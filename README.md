# COM Port to NATS Bridge

This project demonstrates how to connect to a local NATS server and transmit data read from a COM port to it using the NATS .NET Client library.

## Table of Contents

- [Introduction](#introduction)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Testing](#testing)

## Introduction

This project serves as a bridge between a COM port and a NATS server, allowing you to read data from the COM port and publish it to NATS for further processing or distribution.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- .NET Core SDK installed
- A local NATS server running
- A COM port with data to read from

## Installation

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/44East/medical-device-api.git
2. Open the project in your preferred C# IDE.

3. Configure the COM port settings and NATS server URL in the Program.cs file.

4. Build the project.

## Usage   
1. Run the compiled application


2. The application will start listening for data from the COM port.

3. Data read from the COM port will be published to the specified NATS subject.

4. You can customize the NATS subject in the code to match your requirements.

## Testing
To test the application, you can use the following tools:

1. **COM Port Data Emulator** for transmitting data to the virtual COM port.

2. **Virtual Null Modem** for creating virtual COM ports.

