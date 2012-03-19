# @reference ../models/task.coffee

class Tasks extends Backbone.Collection
  model: app.Task
  url: '/api/tasks'
  initialize: (options) ->
    @bind 'destroy', @willDestroyTask, @
  willDestroyTask: (task) ->
    @registerUndo task.toJSON()
  registerUndo: (attributes) ->
    @undoAttributes = attributes
    if @undoAttributes.id
      delete @undoAttributes.id    
  resetUndo: ->
    @undoAttributes = null
  applyUndo: ->
    @create {Name: "#{@undoAttributes.Name} ##{@undoAttributes.Tag}"} if @undoAttributes?
    @resetUndo()
  undoItem: ->
    @undoAttributes
  setDate: (year, month, day) ->
    # Call with a year, a 1-indexed month, and day of month. Or just a Date object.
    if month is undefined and day is undefined
      date = year
      [year, month, day] = [date.getFullYear(), date.getMonth()+1, date.getDate()]
    [@year, @month, @day] = [year, month, day]
    @url = "/api/tasks/#{year}/#{month}/#{day}"
    @resetUndo()
    @fetch()
    @trigger 'change:date'
  currentDate: ->
    new Date(@year, @month-1, @day)
  completedTasks: ->
    @filter (task) ->
      task.isCompleted()  
  incompleteTasks: ->
    @reject (task) ->
      task.isCompleted()
  goToPreviousDate: ->
    date = new Date()
    date.setDate(@currentDate().getDate() - 1)
    @setDate date
  goToNextDate: ->
    date = new Date()
    date.setDate(@currentDate().getDate() + 1)
    @setDate date
@app = window.app ? {}
@app.Tasks = new Tasks