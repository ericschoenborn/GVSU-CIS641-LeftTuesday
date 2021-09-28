# Overview

There are many groups that have a similar workflow that can be sumed up in this need "I need these tasks done in this amount of time, signed off by this person". Though it is a commen need thats easy to understand, the complexity makes it so not many suitable tools exist to fulfill this need and cordinate the information to everyone involved in a real time. LeftTuesday seeks to be the solution to this problem.

Any company with a hierarchical structure that aims to complete tasks will benefit from LeftTuesday. The largest advantage LeftTuesday has over the traditional document is that changes and progress can be viewed in real time.

# Functional Requirements

1. Sending a valid create request to the Session resource shall create a new session.
2. Sending a valid delete request to the Session resource shall delete an existing session.
3. Sending a bad request to the Session resource will return a 500.
4. Sending a valid update request to the Session resource shall update an existing session.

# Non-Functional Requirements

1. Data object shall be persisted in a locally hosted data store.
2. Images shall be stored in a compressed state in a dedicated local directory.
3. Videos shall be stored in a compressed state in a dedicated local directory.
4. Requests shall be consumed by a http style API.
