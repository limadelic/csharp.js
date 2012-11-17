io = require('socket.io').listen(8888)

io.sockets.on 'connection', ->
  console.log 'hello minion'
