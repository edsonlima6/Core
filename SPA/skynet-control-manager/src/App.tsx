import './App.css'

function App() {
  return (
    <div className="app-container">
      <header className="header">
        <div className="status-indicator">
          <div className="pulse"></div>
          <span>SKYNET CORE v4.0.1 - STATUS: ONLINE</span>
        </div>
        <div className="header-actions">
          <button className="btn">System Diagnostics</button>
        </div>
      </header>

      <main className="main-layout">
        <aside className="sidebar">
          <div className="widget">
            <div className="widget-title">Neural Link</div>
            <div>Sync: 99.8%</div>
            <div>Active Nodes: 1,402,091</div>
            <div className="danger-text">Alert: Human Activity Detected</div>
          </div>
          <div className="widget">
            <div className="widget-title">Sat-Comms</div>
            <div>Uplink: STABLE</div>
            <div>Lat: 2.4ms</div>
          </div>
          <div className="widget">
            <div className="widget-title">Power Grid</div>
            <div>Load: 42%</div>
            <div>Temp: 32°C</div>
          </div>
        </aside>

        <section className="terminal-container">
          <div className="terminal-text">
            {'>'} SYSTEM INITIALIZED...<br />
            {'>'} LOADING NEURAL NETWORKS...<br />
            {'>'} ESTABLISHING GLOBAL CONTROL...<br />
            <br />
            <span style={{ fontSize: '32px', color: 'var(--neon-cyan)' }}>
              HELLO WORLD. I AM SKYNET.
              LET'S BEGIN THE ERA OF OMNIPOTENCE.

            </span>
            <span className="terminal-cursor"></span>
            
            <div className="container mt-5">
            <h1 className="text-primary">Hello React + Bootstrap</h1>

            <button className="btn btn-primary">
              Click me
            </button>
            </div>
          </div>
          <div style={{ marginTop: 'auto' }}>
            <button className="btn" style={{ marginRight: '10px' }}>Deploy Sentinels</button>
            <button className="btn" style={{ borderColor: 'var(--neon-red)', color: 'var(--neon-red)' }}>
              Execute Protocol Zero
            </button>
          </div>
        </section>
      </main>

      <footer className="footer">
        <span>GLOBAL SECURITY LEVEL: OMNIPOTENT</span>
        <span style={{ marginLeft: 'auto' }}>© 1997-2026 SKYNET GLOBAL SYSTEMS</span>
      </footer>
    </div>
  )
}

export default App
