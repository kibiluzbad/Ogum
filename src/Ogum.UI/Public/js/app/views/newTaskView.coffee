﻿jQuery ->
  @app = window.app ? {}

  class NewTaskView extends Backbone.View
    tagName: 'newTaskForm'
    template: $("#newTaskViewTemplate")
    initialize: (options) ->
    
    events:
      'keypress #task-text' : 'saveOnEnter'
      'focusout #task-text' : 'hideWarning'      
    render: ->
      if @collection.isToday()
        ($ @el).html @template.tmpl()
        @delegateEvents()
      else
        $(@el).empty()      
      @
    saveOnEnter: (event) ->
      if (event.keyCode is 13) #ENTER
        event.preventDefault()
        newAttirbutes = {Name:$('#task-text').val()}
        errorCallback = {error:@flashWarning}
        if @collection.create(newAttirbutes, errorCallback)
          @hideWarning
          @focus()
    focus: ->
      $('#task-text').val('').focus()
    hideWarning: ->
      $('#warning').hide()
    flashWarning: (model, error) ->
      console.log error
      $('#warning').fadeOut(100)
      $('#warning').fadeIn(400)    
  @app.NewTaskView = NewTaskView