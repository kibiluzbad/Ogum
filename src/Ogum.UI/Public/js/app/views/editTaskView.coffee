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
    saveTask: (event) ->
      event.preventDefault()
      newAttributes = {Name:($ @el).find('.title').val()}
      errorCallback = {error:@flashWarning}

      if @model.save(newAttributes, errorCallback)
        @hideWarning
        @focus()
        @cancelEdit(event)
    focus: ->
      $('#task-text').val('').focus()
    hideWarning: ->
      $('#warning').hide()
    flashWarning: (model, error) ->
      console.log error
      $('#warning').fadeOut(100)
      $('#warning').fadeIn(400)  
    cancelEdit: (event) ->
      event.preventDefault()
      @model.exitEditMode()

  @app.EditTaskView = EditTaskView