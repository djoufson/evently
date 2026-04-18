# PowerPoint Structure - AI + .NET + Azure Session

## Core Message

Modern applications should be designed to become intelligent, not just functional.

---

## Part 1 - The Shift

### 1. Title Slide

- Session title
- Speaker name
- Community / Event

---

### 2. The Gap

- Users expect smart features: recommendations, generation, context awareness
- Most apps are still CRUD-only
- Shift from static apps to intelligent systems

> "The question is not if we use AI, but where we integrate it."

---

### 3. AI as a Layer

- No need to rebuild apps from scratch
- Add AI progressively, feature by feature
- Think of AI as a capability, not a rewrite

---

### 4. Demo Preview

- Event management app (Evently)
- We will enhance it live with:
  - AI-generated event descriptions (text streaming)
  - AI-generated cover images

---

## Part 2 - The Stack

### 5. Our Stack

- .NET (ASP.NET Core + Blazor SSR)
- Azure AI Services
- Semantic Kernel

---

### 6. Why Azure AI

- Secure: data residency, prompts not used for training
- Scalable: production-grade infrastructure
- Enterprise-ready: RBAC, monitoring, compliance

---

### 7. Semantic Kernel - The Glue

- SDK for integrating AI into .NET apps
- The problem with raw AI: unstructured prompts, hard to test, hard to maintain
- Semantic Kernel gives you: prompt management, plugins, clean architecture
- Architecture: `Blazor → API → Semantic Kernel → Azure AI`

---

## Part 3 - Live Demo

### 8. Demo Time

- Start with the CRUD baseline (Phase 0)
- Add description generation with streaming
- Add cover image generation
- Show the code: services, endpoints, JS interop

---

## Part 4 - Wrap Up

### 9. Before & After

- **Before**: static forms, manual content, no intelligence
- **After**: AI-assisted creation, streaming UX, generated visuals
- Lines of code added: minimal — AI lives in the service layer

---

### 10. Resilience & Cost

- Graceful degradation: app works without AI if service is unavailable
- Azure AI pricing: token-based, start with free tier
- Latency: streaming mitigates perceived wait time

---

### 11. Key Takeaways

- AI is a capability you add, not a paradigm you adopt
- Start small: one feature, one prompt, one endpoint
- Keep AI logic in the backend — clean separation
- Azure + Semantic Kernel = production-ready path

---

### 12. Get Started

- GitHub repo: `github.com/djoufson/evently`
- Semantic Kernel docs: `learn.microsoft.com/semantic-kernel`
- Azure AI free tier: `azure.microsoft.com/free`

---

### 13. Final Thought

> "Your next feature might not need more code — it might need a prompt."

---

### 14. Q&A
