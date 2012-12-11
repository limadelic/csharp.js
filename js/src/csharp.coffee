require './minion'

global.using = (full_name) ->

  name = full_name.split('.').pop()

  class @[name]
    
    constructor: ->
      
      Object.defineProperties this,
        id:
          value: 0
          writable: true
        type:
          value: full_name

      minion.create this
