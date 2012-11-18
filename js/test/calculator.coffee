require '../src/csharp'

using 'Math.Calculator'

describe 'A calculator', ->

  calc = new Calculator

  it 'adds', -> calc.add(2, 2).should.equal 4


