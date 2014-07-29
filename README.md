bpmn-validator
==============

BPMN Validator


##Initial tasks
- [ ] Analyse the problem
    - [ ] Review xml scheme
    - [ ] Review xml errors
- [ ] Static design
- [ ] Select best design patter for the solution
- [ ] Choose technologies
- [ ] Create Visual Studio Solution
- [ ] Implement Solution
    - [ ] Implement file uploader
    - [ ] Process XML
    - [ ] Detect BPMN errors
    - [ ] Detect Style errors
    - [ ] Test validation outputs
    - [ ] Integrate cooler file uploader
    - [ ] Implement better styles for results
    - [ ] Implement multiple file processing
    - [ ] Test validation outputs
- [ ] Deploy on Azure
    - [ ] Create Web Site
    - [ ] Configure continuos deployment
- [ ] Test
    - [ ] Validate all files and posible errors

##Validations supported
- Style 0104.  Two activities in the same process should not have the same name.  (Use global activity to reuse a single activity in a process.) [1][1]
- Style 0115.  A throwing intermediate event should be labeled. [1][1]
- Style 0122.  A catching Message event should have incoming message flow.[1][1]
- Style 0123.  A throwing Message event should have outgoing message flow.[1][1
- ]
- BPMN 0102.  All flow objects other than end events and compensating activities must have an outgoing sequence flow, if the process level includes any start or end events.[1][1]

##References
- [1] [The Rules of BPMN][1]

[1]:http://brsilver.com/the-rules-of-bpmn/
[2]:http://wiki.bizagi.com/en/index.php?title=Intermediate_Event#Intermediate_Events
