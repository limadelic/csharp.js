express = require 'express'
http = require 'http'
sio = require 'socket.io'

app = express()
server = http.createServer app

app.configure ->
  @use express.bodyParser()

app.listen 3000

io = sio.listen server

io.sockets.on 'connection', ->
  console.log 'hello baby'
