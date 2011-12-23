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
    @create {Name: "#{@undoAttributes.Name} ##{@undoAttributes.Tag}"} if @undoAttributes
    @resetUndo()
  undoItem: ->
    @undoAttributes
@app = window.app ? {}
@app.Tasks = new Tasks