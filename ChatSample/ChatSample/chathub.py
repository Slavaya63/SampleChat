from flask_socketio import emit,join_room, leave_room, send
from ChatSample import socketio
import uuid


@socketio.on('my broadcast event', namespace='/test')
def test_message(message):
    emit('my response', {'data': message['data']}, broadcast=True)

@socketio.on('connect', namespace='/test')
def test_connect():
    print('Client connected')


@socketio.on('disconnect', namespace='/test')
def test_disconnect():
    print('Client disconnected')


@socketio.on('join', namespace='/test')
def on_join(data):
    print(data)
    username = data['user_id']
    oponent = data['oponent_id']
    room_id = uuid.uuid4().hex
    join_room(room_id)

    emit("join", {'room_id': room_id})
    return "Okey"

@socketio.on('leave', namespace='/test')
def on_leave(data):
    username = data['username']
    room = data['room']
    leave_room(room)
    send(username + ' has left the room.', room=room)

@socketio.on('new_message', namespace='/test')
def message_to_room(data):
    username = data['username']
    room = data['room']
    emit('add message', "New message:" + data['message'], room = room)
    