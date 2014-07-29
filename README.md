bpmn-validator
==============

BPMN Validator

View live demo at: http://bpmn-validator.azurewebsites.net/

##Tasks
- [ ] Analyse the problem
    - [X] Review xml scheme
    - [ ] Review xml errors
- [X] Static design
- [X] Select best design patter for the solution
- [X] Choose technologies
- [X] Create Visual Studio Solution
- [ ] Implement Solution
    - [X] Implement file uploader
    - [X] Process XML
    - [ ] Update class diagram
    - [ ] Detect BPMN errors
    - [ ] Detect Style errors
    - [ ] Test validation outputs
    - [ ] Integrate cooler file uploader
    - [ ] Implement better styles for results
    - [ ] Implement multiple file processing
    - [ ] Test validation outputs
- [X] Deploy on Azure
    - [X] Create Web Site
    - [X] Configure continuous deployment (Continuous delivery)
- [ ] Test
    - [ ] Validate all files and posible errors

##Validations supported
- [ ] Style 0104.  Two activities in the same process should not have the same name.  (Use global activity to reuse a single activity in a process.) [1][1]
- [ ] Style 0115.  A throwing intermediate event should be labeled. [1][1]
- [ ] Style 0122.  A catching Message event should have incoming message flow.[1][1]
- [ ] Style 0123.  A throwing Message event should have outgoing message flow.[1][1]
- [ ] BPMN 0102.  All flow objects other than end events and compensating activities must have an outgoing sequence flow, if the process level includes any start or end events.[1][1]

##Static Design
![Class Diagram](./diagrams/uml_class_diagram.jpg)

##Used Frameworks
- ASP.NET MVC 5
- Linq to XML
- Unity 3
- Unity.Mvc5
- Bootstrap

##Used Tools
[LiqnPad](http://www.linqpad.net/)

##Continuous Delivery
Integration between Azure and GitHub

###GitHub
- master: Main development branch
- pub: deploiment branch

###Windows Azure WebSite
2 Stages configurations:
- main: production application http://bpmn-validator.azurewebsites.net/ 
- stage: test new features http://bpmn-validator-stage.azurewebsites.net/

When all new feature are tested is only swith stage and main stages

##References
- [1] [The Rules of BPMN][1]

[1]:http://brsilver.com/the-rules-of-bpmn/
[2]:http://wiki.bizagi.com/en/index.php?title=Intermediate_Event#Intermediate_Events
