jQuery -> 
  @app = window.app ? {}

  class EditTaskView extends Backbone.View
    template: $('#editTaskViewTemplate')
    tagName: 'li'
    className: 'task edit-mode'
    events:
      "click .save":"saveTask"
      "click .cancel":"cancelEdit"      
    initialize: (options) ->    
      
    render: ->
      html = @template.tmpl @model.toJSON()
      ($ @el).html html
      @
    saveTask: ->
      alert("Salvar vai aqui!")
    cancelEdit: ->
      @model.exitEditMode()

  @app.EditTaskView = EditTaskView