jQuery -> 
  @app = window.app ? {}

  class TaskView extends Backbone.View
    template: $('#taskViewTemplate')
    tagName: 'li'
    className: 'task'
    events:
      "click .destroy":"removeTask"
    initialize: (options) ->    
      
    render: ->
      html = @template.tmpl @model.toJSON()
      ($ @el).html html
      @
    removeTask: ->
      if confirm("Deseja realmente fazer isso?")
        if @model.destroy()
          app.Tasks.fetch()

  @app.TaskView = TaskView