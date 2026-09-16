# Common Code Smells

## Bloaters
- **Long Method**: A method that has grown too large.
- **Large Class**: A class that contains too many fields/methods/lines of code.
- **Primitive Obsession**: Using primitive types instead of small objects for simple tasks (e.g., using a string for a phone number).
- **Long Parameter List**: More than three or four parameters for a method.
- **Data Clumps**: Groups of variables that are always passed around together.

## Object-Orientation Abusers
- **Switch Statements**: Complex switch statements or `if-else` chains (prefer polymorphism).
- **Temporary Field**: Fields that get their values only under certain circumstances.
- **Refused Bequest**: A subclass only uses a few of the methods/properties inherited from its parents.
- **Alternative Classes with Different Interfaces**: Two classes perform identical functions but have different method names.

## Change Preventers
- **Divergent Change**: Having to change many unrelated methods when you make a change to a class.
- **Shotgun Surgery**: Making a single change requires making many small changes to many different classes.
- **Parallel Inheritance Hierarchies**: Whenever you create a subclass for one class, you find yourself having to create a subclass for another class.

## Dispensables
- **Comments**: Comments that explain *what* the code is doing (the code should be self-documenting).
- **Duplicate Code**: The same code structure in more than one place.
- **Lazy Class**: A class that doesn't do enough to justify its existence.
- **Data Class**: A class that contains only fields and crude methods for accessing them (getters/setters).
- **Dead Code**: Code that is no longer used.
- **Speculative Generality**: "Just-in-case" code to support future features that never happen.

## Couplers
- **Feature Envy**: A method that seems more interested in a class other than the one it's in.
- **Inappropriate Intimacy**: One class uses the internal fields and methods of another class.
- **Message Chains**: A client requests another object, that object requests yet another one, and so on (`a.getB().getC().doSomething()`).
- **Middle Man**: A class that performs only one action: delegating work to another class.
