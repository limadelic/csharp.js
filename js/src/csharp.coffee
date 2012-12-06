require './minion'

global.using = (full_name) ->

  { name } = parse full_name

  class @[name]
    constructor: ->
      @full_name = full_name
      minion.create this

parse = (full_name) ->
  namespace: 'Math'
  name: 'Calculator'

