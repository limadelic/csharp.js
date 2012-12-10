class @Awaiter

  wait: -> @sync.await()

  await: (@callback) ->
