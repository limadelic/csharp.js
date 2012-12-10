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
      @object[method] = ((o, m) ->
        -> minion.run o, m, arguments
      )(@object, method)

  run: (@object, method, args) ->
    @socket.emit 'run',
      object: @object
      method: method
      args: args
    @sync.wait_for_result()

  wait_for_result: (@on_result) ->

  result: (value) =>
    console.log JSON.parse value
    @on_result null, 4

global.minion = new Minion
require './server'
