jQuery -> 
  @app = window.app ? {}

  class TasksView extends Backbone.View
    template: $('#tasksViewTemplate')
    tagName: 'ul'
    className: 'tasks'
    initialize: (options) ->
      @collection.bind 'add', @render, @
      @collection.bind 'change', @render, @
      @collection.bind 'destroy', @render, @
    render: ->
      ($ @el).empty()
      
      #Completed tasks
      for task in @collection.completedTasks()
        completedTaskView = new app.CompletedTaskView model: task, collection: @collection
        ($ @el).append completedTaskView.render().el

      #Incomplete tasks
      for task in @collection.incompleteTasks()
        taskView = new app.TaskView model: task, collection: @collection
        ($ @el).append taskView.render().el
      
      #Undo item
      if @collection.undoItem()
        undoView = new app.UndoView collection: @collection
        ($ @el).append undoView.render().el
      @delegateEvents()
      @

  @app.TasksView = TasksView