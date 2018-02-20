# SignalRServerWithCppClient
A client server application with .Net and Cpp clients working with SignalR server which is console hosted.

This repo builds upopn following main repo(https://github.com/Microsoft/cpprestsdk) to be able to work in C++ just like Task Parallel 
library in .Net. Additionally, I used the preview code to build the C++ signalR client described more in detail:
https://blog.3d-logic.com/2015/05/20/signalr-native-client/

The main idea is to be able to setup a C++ client as well as .Net client almost in same ways who get progress update from a server in a
live way as data becomes available.

In production code we connect old legacy code in C++, with new applications build on .Net to come together in doing cross-process 
communications.


