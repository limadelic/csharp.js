require './minion'

global.using = (full_name) ->

  name = full_name.split('.').pop()

  class @[name]
    constructor: ->
      @name = full_name
      minion.create this
