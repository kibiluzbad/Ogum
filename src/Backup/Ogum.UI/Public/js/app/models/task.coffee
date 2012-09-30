
class Task extends Backbone.Model
  idAttribute: 'Id'
  url: ->
    if @id?
      "/api/tasks/#{@id}"
    else
      "/api/tasks"
  initialize: ->
    @editMode = false
    @bind 'edit-mode', @enterEditMode, @
  validate: (attributes) ->
    mergedAttributes = _.extend(_.clone(@attributes),attributes)
    if !mergedAttributes.Name or mergedAttributes.Name.trim() == ''
      return 'Informe o titulo da tarefa.'
  complete: ->
    @set {Status: "Completed"}
  incomplete: ->
    @set {Status: "Incompleted"}
  isCompleted: ->
    @attributes.Status is 1
  enterEditMode: ->
    @editMode = true
    @collection.trigger 'edit-mode'
  exitEditMode: ->
    @editMode = false
    @collection.trigger 'edit-mode'
@app = window.app ? {}
@app.Task = Task