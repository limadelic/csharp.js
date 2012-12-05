class Minion

  wait_for_connection: (@on_connection) ->
    @on_connetion() if @socket?

  connected: (@socket) ->
    @socket.on 'created', @created
    @socket.on 'result', @result
    @on_connection?()

  create: (@clazz) ->
    @socket.emit 'create', @clazz
    @sync.wait_for_created()

  wait_for_created: (@on_created) ->
    console.log 'waiting ...'

  created: (clazz) =>
    clazz = JSON.parse clazz
    console.log clazz
    for method in clazz.methods
      @clazz[method] = => @do clazz, method, arguments
    @on_created()

  do: -> 4

  result: ->

global.minion = new Minion

{ spawn } = require 'child_process'
port = 8888
io = require('socket.io').listen(port)

io.sockets.on 'connection', (socket) =>
  minion.connected socket

spawn 'minion', [port],
  cwd: '../csharp/src/bin/Debug'

minion.sync.wait_for_connection()

