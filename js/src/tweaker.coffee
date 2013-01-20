@tweak = (object, data) ->
  object.id = data.id
  define object, data.methods

String.prototype.toJson = ->
  JSON.parse this

define = (object, methods) ->

  run = (o, m) ->
    (args...) -> minion.run o, m, args

  for method in methods
    object[method] = run object, method
