require '../src/csharp'

using 'Math.Calculator'

describe 'A calculator', ->

  console.log calc = new Calculator

  it 'adds', -> calc.add(2, 2).should.equal 4
