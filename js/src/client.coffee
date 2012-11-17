io = require 'socket.io-client'
socket = io.connect 'http://localhost:8888'

socket.on 'connect', -> console.log 'yes master!'

socket.on 'error', (e) -> console.log 'huh oh ... ' + e

setTimeout null, 20000

