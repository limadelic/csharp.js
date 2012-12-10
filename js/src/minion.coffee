class Minion

  { copy, define } = require './tweaker'
  { Awaiter } = require './awaiter'

  constructor: ->
    @awaiter = new Awaiter

  wait_for_connection: ->
    @awaiter.wait @socket?

  connected: (@socket) ->
    @socket.on 'created', @created
    @socket.on 'result', @result
    @awaiter.callback()

  create: (@object) ->
    @socket.emit 'create',
      type: @object.type
    @awaiter.wait()

  created: (response) =>
    response = JSON.parse response
    copy @object, response.object
    define @object, response.methods
    @awaiter.callback()

  run: (@object, method, args) ->
    @socket.emit 'run',
      object: @object
      method: method
      args: args
    @awaiter.wait()

  result: (value) =>
    console.log JSON.parse value
    @awaiter.callback null, 4

global.minion = new Minion
require './server'
