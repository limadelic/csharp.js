class Minion

  { tweak } = require './tweaker'
  { Awaiter } = require './awaiter'

  constructor: ->
    @awaiter = new Awaiter

  connect: ->
    @awaiter.wait() unless @socket?

  connected: (@socket) ->
    @socket.on 'created', @created
    @socket.on 'result', @result
    @awaiter.callback()

  create: (@object) ->
    @socket.emit 'create',
      type: @object.type
    @awaiter.wait()

  created: (response) =>
    tweak @object, response.toJson()
    @awaiter.callback()

  run: (object, method, args) ->
    @socket.emit 'run',
      id: object.id
      method: method
      args: args
    @awaiter.wait()

  result: (value) =>
    console.log value
    @awaiter.callback null, 4

global.minion = new Minion
require './server'
