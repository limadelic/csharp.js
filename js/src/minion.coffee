io = require('socket.io').listen(8888)

io.sockets.on 'connection', (socket) ->
  socket.emit 'create', { type: 'Math.Calculator' }
  socket.on 'created', (data) -> console.log 'created' + data.Json

@create = ->

@do = -> 4
