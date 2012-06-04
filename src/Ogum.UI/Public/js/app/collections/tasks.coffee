# @reference ../../lib/xdate.js
# @reference ../models/task.coffee

class Tasks extends Backbone.Collection
  model: app.Task
  url: '/api/tasks'
  initialize: (options) ->
    @bind 'destroy', @willDestroyTask, @
    @bind 'edit-mode', @enterEditMode, @    
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
      [year, month, day] = [date.getFullYear(), date.getMonth(), date.getDate()]
    [@year, @month, @day] = [year, month, day]
    
    @url = "/api/tasks/#{year}/#{month}/#{day}"
    
    Backbone.history.navigate @url.replace("/api",""), false
    
    @resetUndo()
    @fetch()
    @trigger 'change:date'
  currentDate: ->
    new XDate(@year, @month, @day)
  completedTasks: ->
    @filter (task) ->
      task.isCompleted()  
  incompleteTasks: ->
    @reject (task) ->
      task.isCompleted()
  goToPreviousDate: ->
    date = @currentDate().addDays(-1);
    @setDate(date)
  goToNextDate: ->
    date = @currentDate().addDays(1);
    @setDate(date)
  isToday: ->
    #Returns true if today is the date being tracked by this Collection.
    date = @currentDate()
    today = XDate.today().toDate()
    date.getFullYear() == today.getFullYear() and
      date.getMonth() == today.getMonth() and
      date.getDate() == today.getDate()
  enterEditMode: ->
    @trigger 'change'
@app = window.app ? {}
@app.Tasks = new Tasks