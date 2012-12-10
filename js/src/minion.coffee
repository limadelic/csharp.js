class Minion

  { copy, define } = require './tweaker'

  wait_for_connection: (@on_connection) ->
    @on_connetion() if @socket?

  connected: (@socket) ->
    @socket.on 'created', @created
    @socket.on 'result', @result
    @on_connection?()

  create: (@object) ->
    @socket.emit 'create',
      type: @object.type
    @sync.wait_for_created()

  wait_for_created: (@on_created) ->

  created: (response) =>
    response = JSON.parse response
    copy @object, response.object
    define @object, response.methods
    @on_created()

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
