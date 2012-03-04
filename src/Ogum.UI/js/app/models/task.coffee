
class Task extends Backbone.Model
  idAttribute: 'Id'
  url: ->
    if @id?
      "/api/tasks/#{@id}"
    else
      "/api/tasks"
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
@app = window.app ? {}
@app.Task = Task