require './minion'

global.using = (full_name) ->

  name = full_name.split('.').pop()

  class @[name]
    
    constructor: ->
      
      Object.defineProperties this,
        type:
          value: full_name

      minion.create this
