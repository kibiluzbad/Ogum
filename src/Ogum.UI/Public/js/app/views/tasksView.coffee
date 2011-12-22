jQuery -> 
  @app = window.app ? {}

  class TasksView extends Backbone.View
    template: $('#tasksViewTemplate')
    tagName: 'ul'
    className: 'tasks'
    initialize: (options) ->    
      
    render: ->
      ($ @el).empty()
      for task in @collection.models
        taskView = new app.TaskView model: task, collection: @collection
        ($ @el).append(taskView.render().el)
      @

  @app.TasksView = TasksView