jQuery -> 
  @app = window.app ? {}

  class TaskView extends Backbone.View
    template: $('#taskViewTemplate')
    tagName: 'li'
    className: 'task'
    events:
      "click .destroy":"removeTask"
      "click .is-done":"markAsCompleted"
    initialize: (options) ->    
      
    render: ->
      html = @template.tmpl @model.toJSON()
      ($ @el).html html
      @
    removeTask: ->
      @model.destroy()
    markAsCompleted: ->
      if @$('.is-done').prop('checked')
        @model.complete()
      else
        @model.incomplete()
      @model.save()
  @app.TaskView = TaskView