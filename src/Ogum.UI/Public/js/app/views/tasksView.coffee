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
      for task in @collection.models
        taskView = new app.TaskView model: task, collection: @collection
        ($ @el).append taskView.render().el
      if @collection.undoItem()
        undoView = new app.UndoView collection: @collection
        ($ @el).append undoView.render().el
      @

  @app.TasksView = TasksView