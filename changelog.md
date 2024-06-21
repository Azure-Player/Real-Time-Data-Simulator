# Changelog - Real-Time-Data-Simulator

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [0.2.0] - 2024-06-21
### Features
* Added reuse of compiled C# expressions from message payload, repeated use of an expression executes faster
* Limit use to single EventSender and Single EventHubProducerClient across all threads
* Updated completion logic that requires all threads to complete before updating UI
* Some tweaks to reduce locking of UI during execution

## [0.1.0] - 2024-06-07
* First release with basic features.
