class @Awaiter

  wait: (@condition) ->
    @sync.await()

  await: (@callback) ->
    @callback() if @condition
