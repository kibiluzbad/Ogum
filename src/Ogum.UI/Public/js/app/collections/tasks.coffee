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
    [@year, @month, @day] = [year, month, day]
    @url = "/api/tasks/#{year}/#{month}/#{day}" 
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
@app = window.app ? {}
@app.Tasks = new Tasks