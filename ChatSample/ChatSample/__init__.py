"""
The flask application package.
"""

from flask import Flask
from flask_socketio  import SocketIO

app = Flask(__name__)
socketio = SocketIO(app)


import ChatSample.views
import ChatSample.chathub
