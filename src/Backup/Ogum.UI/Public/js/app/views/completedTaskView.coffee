jQuery -> 
  @app = window.app ? {}

  class CompletedTaskView extends Backbone.View
    template: $('#completedTaskViewTemplate')
    tagName: 'li'
    className: 'task done'
    events:
      "click .is-done":"markAsIncomplete"
    initialize: (options) ->    
      
    render: ->
      html = @template.tmpl @model.toJSON()
      ($ @el).html html
      @

    markAsIncomplete: ->
      if @$('.is-done').prop('checked')
        @model.complete()
      else
        @model.incomplete()
      @model.save()
  @app.CompletedTaskView = CompletedTaskView