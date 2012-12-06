class Minion

  wait_for_connection: (@on_connection) ->
    @on_connetion() if @socket?

  connected: (@socket) ->
    @socket.on 'created', @created
    @socket.on 'result', @result
    @on_connection?()

  create: (@object) ->
    @socket.emit 'create', @object
    @sync.wait_for_created()

  wait_for_created: (@on_created) ->

  created: (created_object) =>
    @created_object = JSON.parse created_object
    @init_properties()
    @define_methods()
    @on_created()

  init_properties: ->
    @object[property] = value for property, value of @created_object

  define_methods: ->
    for method in @created_object.methods
      @object[method] = -> minion.run @object, method, arguments

  run: -> 4

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

