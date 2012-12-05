require './minion'

global.using = (full_name) ->

  { namespace, name } = parse full_name

  class @[name]
    constructor: ->
      @namespace = namespace
      @name = name
      minion.create this

parse = (full_name) ->
  namespace: 'Math'
  name: 'Calculator'

