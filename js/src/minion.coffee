io = require('socket.io').listen(8888)

io.sockets.on 'connection', (socket) ->
  socket.on 'created', created
  socket.on 'result', result
  
@create = (clazz) ->
  socket.emit 'create', clazz
  clazz.methods = ['add']
  clazz

created = (clazz) ->
  for method in clazz.methods
    clazz[method] = -> @do clazz, method, arguments

@do = -> 4

result = ->
