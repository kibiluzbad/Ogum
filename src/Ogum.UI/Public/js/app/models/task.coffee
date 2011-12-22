
class Task extends Backbone.Model
  idAttribute: 'Id'
  validate: (attributes) ->
    mergedAttributes = _.extend(_.clone(@attributes),attributes)
    if !mergedAttributes.Name or mergedAttributes.Name.trim() == ''
      return 'Informe o titulo da tarefa.'

@app = window.app ? {}
@app.Task = Task