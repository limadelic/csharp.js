minion = require './minion'

global.using = (full_name) ->

  { namespace, clazz } = parse full_name

  class @[clazz]
    namespace: namespace
    name: clazz
    constructor: ->
      minion.create this
      @add = -> minion.do this, 'add', arguments

parse = (full_name) ->
  namespace: 'Math'
  clazz: 'Calculator'
