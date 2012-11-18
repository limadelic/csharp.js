global.using = (full_name) ->

  namespace = 'Math'
  clazz = 'Calculator'

  class @[clazz]
    namespace: namespace
    name: clazz
    constructor: ->
      @add = (x, y) -> x + y
