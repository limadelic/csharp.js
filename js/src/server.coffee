{ spawn } = require 'child_process'

port = 8888
io = require('socket.io').listen(port)

io.sockets.on 'connection', (socket) =>
  minion.connected socket

spawn 'minion', [port],
  cwd: '../csharp/src/bin/Debug'

minion.sync.wait_for_connection()
