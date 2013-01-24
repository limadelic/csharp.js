{ spawn } = require 'child_process'

port = 8888
io = require('socket.io').listen(port)
io.set 'log level', 0

io.sockets.on 'connection', (socket) ->
  minion.connected socket

io.client = spawn 'csharp', [port],
  cwd: "#{__dirname}/../bin/csharp"

minion.connect io
