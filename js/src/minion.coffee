{ spawn } = require 'child_process'
port = 8888
io = require('socket.io').listen(port)

io.sockets.on 'connection', (@socket) ->
  @socket.on 'created', created
  @socket.on 'result', result

spawn 'test.bat', [port],
  cwd: '../csharp/src/bin/Debug'

@create = (clazz) ->
  @socket.emit 'create', clazz
  clazz.methods = ['add']
  clazz

created = (clazz) ->
  for method in clazz.methods
    clazz[method] = -> @do clazz, method, arguments

@do = -> 4

result = ->
