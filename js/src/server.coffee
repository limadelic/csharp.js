{ spawn } = require 'child_process'

port = 8888
io = require('socket.io').listen(port)

io.sockets.on 'connection', (socket) ->
  minion.connected socket

spawn 'csharp', [port],
  cwd: "#{__dirname}/../bin/csharp"

minion.connect()
