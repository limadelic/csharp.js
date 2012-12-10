@tweak = (object, data) ->
  copy object, data.object
  define object, data.methods

String.prototype.toJson = ->
  JSON.parse this

copy = (object, values) ->
  for property, value of values
    object[property] = value

define = (object, methods) ->

  run = (o, m) ->
    -> minion.run o, m, arguments

  for method in methods
    object[method] = run object, method
